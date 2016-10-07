package RestControllers;

import Models.AcceleroMeter;
import Models.Pressure;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/acceleroMeter")
public class AcceleroMeterRestController {

    @RequestMapping(method = RequestMethod.GET)
    public List<AcceleroMeter> getAcceleroMeterRange(@RequestParam(value = "amount") int amount) {
        return new ArrayList<AcceleroMeter>();
    }

    @RequestMapping(method = RequestMethod.POST)
    public AcceleroMeter addAcceleroMeter(@RequestBody AcceleroMeter acceleroMeter) {
        return new AcceleroMeter();
    }

}
