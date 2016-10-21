package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.AcceleroMeter;
import be.pxl.backend.services.AcceleroMeterService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/acceleroMeter")
public class AcceleroMeterRestController {

    @Autowired
    private AcceleroMeterService acceleroMeterService;

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.GET)
    public List<AcceleroMeter> getAcceleroMeterRange(@RequestParam(value = "id") int id) {
        return acceleroMeterService.getAcceleroMetersForSession(id);
    }

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.POST)
    public AcceleroMeter addAcceleroMeter(@RequestBody AcceleroMeter acceleroMeter) {
        return acceleroMeterService.addAcceleroMeter(acceleroMeter);
    }

}
