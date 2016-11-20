package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Pressure;
import be.pxl.backend.services.PressureService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;
import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/pressure")
public class PressureRestController {

    @Autowired
    private PressureService pressureService;

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.GET)
    public List<Pressure> getPressuresFromSession(@RequestParam(value = "id") int id) {
        return pressureService.getPressuresForSession(id);
    }

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.POST, consumes = MediaType.APPLICATION_JSON_VALUE)
    public Pressure addPressure(@RequestBody Pressure pressure) {
        return pressureService.addPressure(pressure);
    }

}
