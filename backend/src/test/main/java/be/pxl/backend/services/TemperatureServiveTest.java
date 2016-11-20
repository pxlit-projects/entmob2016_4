package be.pxl.backend.services;

import static org.mockito.Mockito.when;

import be.pxl.backend.exceptions.TemperatureException;
import be.pxl.backend.models.Temperature;
import be.pxl.backend.repositories.TemperatureRepository;
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
public class TemperatureServiveTest {

    @Autowired
    private TemperatureService temperatureService;

    private TemperatureRepository temperatureRepository;

    @Before
    public void init() {
        temperatureRepository = Mockito.mock(TemperatureRepository.class);
    }

    @Test(expected = TemperatureException.class)
    public void temperatureFailedToLow() {
        Temperature temperature = new Temperature(-900, new Date());
        temperatureService.addtemperature(temperature);
    }

    @Test(expected = TemperatureException.class)
    public void temperatureFailedToHigh() {
        Temperature temperature = new Temperature(300, new Date());
        temperatureService.addtemperature(temperature);
    }

    @Test
    public void temperatureSucces() {
        Temperature temperature = new Temperature(20, new Date());
        when(temperatureRepository.save(temperature)).thenReturn(temperature);
        temperatureService.addtemperature(temperature);
    }

}
