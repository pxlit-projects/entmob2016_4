package be.pxl.backend.repositories;

import be.pxl.backend.dao.SessionDao;
import be.pxl.backend.models.Session;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.stereotype.Repository;

import javax.persistence.*;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository("sessionRepository")
public class SessionRepository implements SessionDao  {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    @Transactional
    public Session startSession(Session session) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();

        em.persist(session);

        et.commit();
        em.close();

        return session;
    }

    @Transactional
    public Session stopSession(Session session) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();

        em.merge(session);

        et.commit();
        em.close();

        return session;
    }

    @Transactional
    public List<Session> allSessions() {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();

        Query query = em.createQuery("from Sessions");
        List results = query.getResultList();

        et.commit();
        em.close();

        return results;
    }

    @Transactional
    public Session getSessionById(int id) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();

        Session session = em.find(Session.class, id);

        et.commit();
        em.close();

        return session;
    }
}
