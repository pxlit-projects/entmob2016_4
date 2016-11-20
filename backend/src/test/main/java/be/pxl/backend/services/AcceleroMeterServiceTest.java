package be.pxl.backend.services;

import be.pxl.backend.exceptions.AcceleroMeterException;
import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.repositories.AcceleroMeterRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;

/**
 * Created by Jonas on 20/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class AcceleroMeterServiceTest {

    @Autowired
    private AcceleroMeterService acceleroMeterService;

    private AcceleroMeterRepository acceleroMeterRepository;


    @Before
    public void init() {
        acceleroMeterRepository = Mockito.mock(AcceleroMeterRepository.class);
    }

    @Test(expected = AcceleroMeterException.class)
    public void addAcceleroMeterFailedToLow() {
        AcceleroMeter acceleroMeter = new AcceleroMeter(0,0,-4, new Date());
        acceleroMeterService.addAcceleroMeter(acceleroMeter);
    }

    @Test(expected = AcceleroMeterException.class)
    public void addAcceleroMeterFailedToHigh() {
        AcceleroMeter acceleroMeter = new AcceleroMeter(-1,2,7, new Date());
        acceleroMeterService.addAcceleroMeter(acceleroMeter);
    }

    @Test
    public void addAcceleroMeterSucces() {
        AcceleroMeter acceleroMeter = new AcceleroMeter(1,-2,3, new Date());
        Mockito.when(acceleroMeterRepository.save(acceleroMeter)).thenReturn(acceleroMeter);
        acceleroMeterService.addAcceleroMeter(acceleroMeter);
    }
}
