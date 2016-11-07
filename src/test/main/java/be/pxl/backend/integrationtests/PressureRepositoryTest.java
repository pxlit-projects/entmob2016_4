package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;

import be.pxl.backend.models.Pressure;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.PressureRepository;
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
 * Created by Jonas on 4/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
@DirtiesContext
public class PressureRepositoryTest {

    @Autowired
    private SessionRepository sessionRepository;

    @Autowired
    private PressureRepository pressureRepository;

    public void deleteAll() {
        pressureRepository.deleteAll();
        sessionRepository.deleteAll();
    }

    @Test
    public void addPressureSucces() {
        deleteAll();

        Pressure pressure = new Pressure(1000, new Date());
        Pressure savedPressure = pressureRepository.save(pressure);

        assertEquals(pressure.getDate(), savedPressure.getDate());
        assertEquals(pressure.getPressure(), savedPressure.getPressure(), 0);
    }

    @Test(expected = Exception.class)
    public void addPressureFailed() {
        deleteAll();

        Pressure pressure = new Pressure();
        pressureRepository.save(pressure);
    }

    @Test
    public void getPressuresForSession() {
        deleteAll();

        Session session = new Session();
        Session savedSession = sessionRepository.save(session);

        Pressure pressure1 = new Pressure(1000, new Date());
        pressure1.setSession(savedSession);

        Pressure pressure2 = new Pressure(5000, new Date());
        pressure2.setSession(savedSession);

        pressureRepository.save(pressure1);
        pressureRepository.save(pressure2);

        List<Pressure> pressures = pressureRepository.getPressuresForSession(savedSession.getId());

        assertEquals(pressures.size(), 2);
        assertEquals(6000, pressures.stream().mapToDouble(p -> p.getPressure()).sum(), 0);
    }

}
