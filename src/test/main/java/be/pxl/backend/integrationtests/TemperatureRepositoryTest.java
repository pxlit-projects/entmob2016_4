package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;

import be.pxl.backend.models.Session;
import be.pxl.backend.models.Temperature;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.repositories.TemperatureRepository;
import be.pxl.backend.start.Application;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 4/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
//@ContextConfiguration(classes = Application.class)
@DirtiesContext
public class TemperatureRepositoryTest {

    @Autowired
    private SessionRepository sessionRepository;

    @Autowired
    private TemperatureRepository temperatureRepository;

    public void deleteAll() {
        temperatureRepository.deleteAll();
    }

    @Test
    public void addTemperature() {
        deleteAll();

        Temperature temperature = new Temperature(20, new Date());
        Temperature savedTemperature = temperatureRepository.save(temperature);

        assertEquals(temperature.getDate(), savedTemperature.getDate());
        assertEquals(temperature.getTemperature(), savedTemperature.getTemperature(), 0);
    }

    @Test
    public void getTemperaturesForSession() {
        deleteAll();

        Session session = new Session();
        Session savedSession = sessionRepository.save(session);

        Temperature temperature1 = new Temperature(20, new Date());
        temperature1.setSession(savedSession);
        Temperature temperature2 = new Temperature(20, new Date());
        temperature2.setSession(savedSession);

        temperatureRepository.save(temperature1);
        temperatureRepository.save(temperature2);

        List<Temperature> temperatures = temperatureRepository.getTemperaturesForSession(savedSession.getId());

        assertEquals(2, temperatures.size());
    }
}
