package be.pxl.backend.restcontrollers;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.models.User;
import be.pxl.backend.services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/user")
public class UserRestController {

    @Autowired
    private UserService userService;

    @Secured("ROLE_USER")
    @RequestMapping(method = RequestMethod.GET)
    public User getUserByUsername(@RequestParam(value = "username") String username) {
        return userService.getUserByUsername(username);
    }

    @Secured("ROLE_ADMIN")
    @RequestMapping(method = RequestMethod.GET, value = "/all")
    public List<User> getAllUsers() {
        return userService.getAllUsers();
    }

    @Secured({"ROLE_GUEST", "ROLE_USER", "ROLE_ADMIN"})
    @RequestMapping(method = RequestMethod.POST)
    public User addUser(@RequestBody User user) {
        User savedUser = userService.addUser(user);
        return savedUser;
    }

}
