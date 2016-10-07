package be.pxl.backend.RestControllers;

import be.pxl.backend.Models.Humidity;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@RestController
@RequestMapping("/humdity")
public class HumidityRestController {

    @RequestMapping(method = RequestMethod.GET)
    public List<Humidity> getHumidityRange(@RequestParam(value = "amount") int amount) {
        return new ArrayList<Humidity>();
    }

    @RequestMapping(method = RequestMethod.POST)
    public Humidity addHumidity(@RequestBody Humidity humidity) {
        return new Humidity();
    }

}
