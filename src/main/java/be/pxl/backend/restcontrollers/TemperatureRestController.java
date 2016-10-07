package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Temperature;
import org.springframework.web.bind.annotation.*;
import java.util.*;


/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/temperature")
public class TemperatureRestController {

    @RequestMapping(method = RequestMethod.GET)
    public List<Temperature> getTemperaturesForSession(@RequestParam(value = "sessionId") int sessionId) {
        return new ArrayList<Temperature>();
    }

    @RequestMapping(method = RequestMethod.POST)
    public Temperature addTemperature(@RequestBody Temperature temperature) {
        return new Temperature();
    }

}
