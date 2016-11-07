package be.pxl.backend.services;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class UserServiceTest {

    @Mock
    private JmsSender jmsSender;

    @Mock
    private UserRepository userRepository;

    private UserService userService;

    @Before
    public void init() {
        MockitoAnnotations.initMocks(this);
        userService = new UserService();
        userService.setUserRepository(userRepository);
        userService.setJmsSender(jmsSender);
    }

    @Test(expected = UserException.class)
    public void addUserFailed() {
        User user = new User();
        user.setPassword("abc");
        user.setName("jonas");
       userService.addUser(user);
    }

    @Test
    public void addUserSucces() {
        User user = new User();
        user.setName("Jonas");
        user.setPassword("123456");
        userService.addUser(user);
        assertEquals("Jonas", user.getName());
        assertTrue(new BCryptPasswordEncoder().matches("123456", user.getPassword()));
    }

}
