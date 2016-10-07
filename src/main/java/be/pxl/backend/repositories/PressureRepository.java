package be.pxl.backend.repositories;

import be.pxl.backend.dao.PressureDao;
import be.pxl.backend.models.Pressure;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository("pressureRepository")
public class PressureRepository implements PressureDao {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    public Pressure addPresure(Pressure pressure) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();
        et.begin();

        em.persist(pressure);

        et.commit();
        em.close();

        return pressure;
    }

}
