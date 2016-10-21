package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Humidity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@RestController
@RequestMapping("/humdity")
public class HumidityRestController {

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.GET)
    public List<Humidity> getHumidityRange(@RequestParam(value = "amount") int amount) {
        return new ArrayList<Humidity>();
    }

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.POST)
    public Humidity addHumidity(@RequestBody Humidity humidity) {
        return new Humidity();
    }

}
