package be.pxl.backend.repositories;

import be.pxl.backend.dao.UserDao;
import be.pxl.backend.models.User;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository("userRepository")
public class UserRepository implements UserDao {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    @Transactional
    public User getUserById(int id) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();
        User user = em.find(User.class, id);
        et.commit();
        em.close();
        return user;
    }

    @Transactional
    public User addUser(User user) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();
        em.persist(user);
        et.commit();
        em.close();
        return user;
    }

}

