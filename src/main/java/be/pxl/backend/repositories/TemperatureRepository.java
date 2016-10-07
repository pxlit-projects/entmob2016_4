package be.pxl.backend.repositories;

import be.pxl.backend.dao.TemperatureDao;
import be.pxl.backend.models.Temperature;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository("temperatureRepository")
public class TemperatureRepository implements TemperatureDao {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    @Transactional
    public Temperature addTemperature(Temperature temperature, int sessionId) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();

        em.persist(temperature);

        et.commit();
        em.close();

        return temperature;
    }

}
