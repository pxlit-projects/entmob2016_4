package be.pxl.backend.services;

import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

import be.pxl.backend.TestApplication;
import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class UserServiceTest {

    @Autowired
    private UserService userService;

    private UserRepository userRepository;

    @Before
    public void init() {
        userRepository = mock(UserRepository.class);
    }

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

        when(userRepository.save(user)).thenReturn(user);
        User savedUser = userService.addUser(user);

        assertTrue(new BCryptPasswordEncoder().matches("abcdef", savedUser.getPassword()));
    }
}
