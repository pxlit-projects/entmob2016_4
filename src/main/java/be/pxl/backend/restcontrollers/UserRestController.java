package be.pxl.backend.restcontrollers;

import be.pxl.backend.models.User;
import be.pxl.backend.services.UserService;
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
    public User addNewUser(@RequestBody User user) {
        //User savedUser = userService.addUser(user);
        return new User();//savedUser;
    }

}
