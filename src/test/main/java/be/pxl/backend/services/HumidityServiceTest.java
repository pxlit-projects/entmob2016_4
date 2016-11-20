package be.pxl.backend.services;

import be.pxl.backend.exceptions.HumidityException;
import be.pxl.backend.models.Humidity;
import be.pxl.backend.repositories.HumidityRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import java.util.Date;

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class HumidityServiceTest {

    @Autowired
    private HumidityService humidityService;

    private HumidityRepository humidityRepository;

    @Before
    public void init() {
        humidityRepository = mock(HumidityRepository.class);
    }

    @Test(expected = HumidityException.class)
    public void addHumidityFailedToLow() {
        Humidity humidity = new Humidity(-10, new Date());
        humidityService.addhumidity(humidity);
    }

    @Test(expected = HumidityException.class)
    public void addHumidityFailedToHigh() {
        Humidity humidity = new Humidity(101, new Date());
        humidityService.addhumidity(humidity);
    }

    @Test
    public void addHumiditySucces() {
        Humidity humidity = new Humidity(56, new Date());
        when(humidityRepository.save(humidity)).thenReturn(humidity);
        humidityService.addhumidity(humidity);
    }

}



