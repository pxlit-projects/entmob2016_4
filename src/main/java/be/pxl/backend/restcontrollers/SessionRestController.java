package be.pxl.backend.restcontrollers;
import be.pxl.backend.models.Session;
import be.pxl.backend.models.User;
import be.pxl.backend.services.SessionService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.access.annotation.Secured;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
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

    @Secured({"ROLE_USER"})
    @RequestMapping(method = RequestMethod.GET)
    public Session getSessionById(@RequestParam(value = "id") int id) {
        Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        String name = auth.getName();
        return sessionService.getSessionById(id);
    }

    @Secured({"ROLE_USER"})
    @RequestMapping(method = RequestMethod.GET, value = "/all")
    public List<Session> getAllSessions() {
        Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        String name = auth.getName();
        System.out.println(name);
        return sessionService.getAllSessions(name);
    }

    @Secured({"ROLE_USER"})
    @RequestMapping(method = RequestMethod.POST, value = "/start")
    public Session startSession(@RequestBody Session session) {
        return sessionService.startSession(session);
    }

    @Secured({"ROLE_USER"})
    @RequestMapping(method = RequestMethod.PUT, value = "/stop")
    public Session stopSession(@RequestBody Session session) {
        return sessionService.stopSession(session);
    }

}
