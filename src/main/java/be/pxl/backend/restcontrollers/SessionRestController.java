package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Session;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/session")
public class SessionRestController {

    @RequestMapping(method = RequestMethod.GET)
    public Session getSessionById(@RequestParam(value = "id") int id) {
        return new Session();
    }

    @RequestMapping(method = RequestMethod.GET, value = "/all")
    public List<Session> getAllSessions() {
        return new ArrayList<>();
    }

    @RequestMapping(method = RequestMethod.POST, value = "/start")
    public Session startSession(@RequestParam(value = "start") Date start) {
        return new Session();
    }

    @RequestMapping(method = RequestMethod.POST, value = "/stop")
    public Session stopSession(@RequestBody Session session) {
        return new Session();
    }

}
