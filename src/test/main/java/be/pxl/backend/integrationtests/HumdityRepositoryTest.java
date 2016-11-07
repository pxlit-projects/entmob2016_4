package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNotNull;

import be.pxl.backend.models.Humidity;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.HumidityRepository;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.start.Application;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 6/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
@DirtiesContext
public class HumdityRepositoryTest {

    @Autowired
    private HumidityRepository humidityRepository;

    @Autowired
    private SessionRepository sessionRepository;

    public void deletelAll() {
        humidityRepository.deleteAll();
    }

    @Test
    public void addHumiditySucces(){
        deletelAll();

        Humidity humidity = new Humidity(20, new Date());
        Humidity savedHumidity = humidityRepository.save(humidity);

        assertEquals(humidity.getDate(), savedHumidity.getDate());
        assertEquals(humidity.getHumidity(), savedHumidity.getHumidity(), 0);
        assertNotNull(humidity.getId());
    }

    @Test(expected = Exception.class)
    public void addHumidityFailed() {
        deletelAll();

        Humidity humidity = new Humidity();
        humidityRepository.save(humidity);
    }

    @Test
    public void getHumiditiesForSession(){
        deletelAll();

        Session session = new Session();
        Session savedSession = sessionRepository.save(session);

        Humidity humidity = new Humidity(10, new Date());
        Humidity humidity1 = new Humidity(80, new Date());
        Humidity humidity2 = new Humidity(90, new Date());

        humidity1.setSession(session);
        humidity2.setSession(session);

        humidityRepository.save(humidity);
        humidityRepository.save(humidity1);
        humidityRepository.save(humidity2);

        List<Humidity> humidities = humidityRepository.getHumidityForSession(savedSession.getId());
        assertEquals(2, humidities.size());
        assertEquals(170, humidities.stream().mapToDouble(h -> h.getHumidity()).sum(), 0);
    }

}
