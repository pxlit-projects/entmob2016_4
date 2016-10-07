package be.pxl.backend.RestControllers;

import be.pxl.backend.Models.Pressure;
import org.springframework.web.bind.annotation.*;
import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/pressure")
public class PressureRestController {

    @RequestMapping(method = RequestMethod.GET)
    public List<Pressure> getPressuresRange(@RequestParam(value = "amount") int amount) {
        return new ArrayList<Pressure>();
    }

    @RequestMapping(method = RequestMethod.POST)
    public Pressure addPressure(@RequestBody Pressure pressure) {
        return new Pressure();
    }

}
