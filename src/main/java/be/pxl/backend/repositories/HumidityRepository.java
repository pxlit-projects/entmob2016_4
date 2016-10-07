package be.pxl.backend.repositories;

import be.pxl.backend.dao.HumidityDao;
import be.pxl.backend.dao.TemperatureDao;
import be.pxl.backend.models.Humidity;
import be.pxl.backend.models.Temperature;
import org.springframework.stereotype.Repository;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.PersistenceUnit;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository("humidityRepository")
public class HumidityRepository implements HumidityDao {

    private EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }

    public Humidity addHumidity(Humidity humidity) {
        EntityManager em = emf.createEntityManager();
        EntityTransaction et = em.getTransaction();

        em.persist(humidity);

        et.commit();
        em.close();

        return humidity;
    }

}
