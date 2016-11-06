package be.pxl.backend.services;

import static org.junit.Assert.assertEquals;

import be.pxl.backend.exceptions.UserException;
import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by Jonas on 6/11/16.
 */

@ActiveProfiles("test")
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class UserServiceTest {

    @Mock
    private UserRepository userRepository;

    @Autowired
    private UserService userService;

    @Before
    public void init() {
        MockitoAnnotations.initMocks(this);
        userService.setUserRepository(userRepository);
    }

    @Test(expected = UserException.class)
    public void addUserFailed() {
        User user = new User();
        Mockito.when(userService.addUser(user)).thenThrow(UserException.class);
    }

    @Test
    public void addUserSucces() {
        User user = new User();
        user.setName("Jonas");
        user.setPassword("123456");
        Mockito.when(userService.addUser(user)).thenReturn(user);
        assertEquals(user.getName(), "Jonas");
        assertEquals(user.getPassword(), "123456");
    }

}
