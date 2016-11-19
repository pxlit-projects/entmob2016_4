package be.pxl.backend.services;

import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.when;

import be.pxl.backend.TestApplication;
import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = TestApplication.class)
public class UserServiceTest {

    @Autowired
    private JmsSender jmsSender;

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private UserService userService;

    @Test(expected = UserException.class)
    public void addUserFailed() {
        User user = new User("Jonas");
        user.setPassword("abc");

        userService.addUser(user);
    }

    @Test
    public void addUserSucces() {
        User user = new User("Jonas");
        user.setPassword("abcdef");

        when(userService.addUser(user)).thenReturn(user);
        User savedUser = userService.addUser(user);

        assertTrue(new BCryptPasswordEncoder().matches(user.getPassword(), savedUser.getPassword()));
    }
}
