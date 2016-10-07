package be.pxl.backend.repositories;

import be.pxl.backend.dao.AcceleroMeterDao;
import be.pxl.backend.models.AcceleroMeter;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;
import javax.validation.OverridesAttribute;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository("AcceleroMeterRepository")
public class AcceleroMeterRepository implements AcceleroMeterDao {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    public AcceleroMeter addAcceleroMeter(AcceleroMeter acceleroMeter) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();

        em.persist(acceleroMeter);

        et.commit();
        em.close();

        return acceleroMeter;
    }
}
