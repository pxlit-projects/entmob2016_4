package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.Session;
import be.pxl.backend.services.SessionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/session")
public class SessionRestController {

    @Autowired
    private SessionService sessionService;

    @RequestMapping(method = RequestMethod.GET)
    public Session getSessionById(@RequestParam(value = "id") int id) {
        return sessionService.getSessionById(id);
    }

    @RequestMapping(method = RequestMethod.GET, value = "/all")
    public List<Session> getAllSessions() {
        return sessionService.getAllSessions();
    }

    @RequestMapping(method = RequestMethod.POST, value = "/start")
    public Session startSession(@RequestBody Session session) {
        return sessionService.startSession(session);
    }

    @RequestMapping(method = RequestMethod.POST, value = "/stop")
    public Session stopSession(@RequestBody Session session) {
        return sessionService.stopSession(session);
    }

}
