package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Humidity;
import be.pxl.backend.repositories.HumidityRepository;
import be.pxl.backend.services.HumidityService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@RestController
@RequestMapping("/humidity")
public class HumidityRestController {

    @Autowired
    private HumidityService humidityService;

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.GET)
    public List<Humidity> getHumidityRange(@RequestParam(value = "id") int id) {
        return humidityService.getHumidityForSession(id);
    }

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.POST)
    public Humidity addHumidity(@RequestBody Humidity humidity) {
        return humidityService.addhumidity(humidity);
    }

}
