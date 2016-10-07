package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

/**
 * Created by Jonas on 7/10/16.
 */

@RestController
@RequestMapping("/user")
public class UserRestController {

    @RequestMapping(method = RequestMethod.GET)
    public User getUserById(@RequestParam(value = "id") int id) {
        return new User();
    }

    @RequestMapping(method = RequestMethod.POST)
    public User newUser(@RequestBody User user) {
        return new User();
    }

}
