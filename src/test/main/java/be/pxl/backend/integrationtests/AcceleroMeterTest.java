package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;
import static org.hamcrest.CoreMatchers.*;
import static org.junit.Assert.assertThat;

import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.AcceleroMeterRepository;
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
import java.util.stream.Collectors;
import java.util.stream.DoubleStream;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
@DirtiesContext
public class AcceleroMeterTest {

    @Autowired
    private AcceleroMeterRepository acceleroMeterRepository;

    @Autowired
    private SessionRepository sessionRepository;

    public void deleteAll() {
        acceleroMeterRepository.deleteAll();
        sessionRepository.deleteAll();
    }

    @Test
    public void addAcceleroMeterSucces() {
        AcceleroMeter acceleroMeter = new AcceleroMeter(12, 50, 0, new Date());
        AcceleroMeter savedAcceleroMeter = acceleroMeterRepository.save(acceleroMeter);

        assertEquals(acceleroMeter.getDate(), savedAcceleroMeter.getDate());
        assertEquals(acceleroMeter.getX(), savedAcceleroMeter.getX(), 0);
        assertEquals(acceleroMeter.getY(), savedAcceleroMeter.getY(), 0);
        assertEquals(acceleroMeter.getZ(), savedAcceleroMeter.getZ(), 0);
    }

    @Test(expected = Exception.class)
    public void addAcceleroMeterFailed(){
        AcceleroMeter acceleroMeter = new AcceleroMeter();
        acceleroMeterRepository.save(acceleroMeter);
    }

    @Test
    public void getAcceleroMetersForSession() {
        Session session = new Session("Test", new Date());
        session = sessionRepository.save(session);

        AcceleroMeter acceleroMeter1 = new AcceleroMeter(12, 50, 0, new Date());
        AcceleroMeter acceleroMeter2 = new AcceleroMeter(78, 50, 0, new Date());

        acceleroMeter1.setSession(session);
        acceleroMeter2.setSession(session);

        acceleroMeterRepository.save(acceleroMeter1);
        acceleroMeterRepository.save(acceleroMeter2);

        List<AcceleroMeter> acceleroMeters = acceleroMeterRepository.getAcceleroMetersForSession(session.getId());
        assertEquals(2, acceleroMeters.size());

        List<Double> xValues = acceleroMeters.stream().map(a -> (double)a.getX()).collect(Collectors.toList());
        assertThat(xValues, hasItems(12.0, 78.0));
        List<Double> yValues = acceleroMeters.stream().map(a -> (double)a.getY()).collect(Collectors.toList());
        assertThat(yValues, hasItems(50.0, 50.0));
        List<Double> zValues = acceleroMeters.stream().map(a -> (double)a.getZ()).collect(Collectors.toList());
        assertThat(zValues, hasItems(0.0, 0.0));
    }

}
