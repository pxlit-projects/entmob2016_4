package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Temperature;
import be.pxl.backend.repositories.TemperatureRepository;
import be.pxl.backend.services.TemperatureService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.*;


/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/temperature")
public class TemperatureRestController {

    @Autowired
    private TemperatureService temperatureService;

    @RequestMapping(method = RequestMethod.GET)
    public List<Temperature> getTemperaturesForSession(@RequestParam(value = "id") int id) {
        return temperatureService.getTemperaturesForSession(id);
    }

    @RequestMapping(method = RequestMethod.POST)
    public Temperature addTemperature(@RequestBody Temperature temperature) {
        return temperatureService.addtemperature(temperature);
    }

}
