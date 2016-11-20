package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;

import be.pxl.backend.models.User;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

/**
 * Created by Jonas on 4/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
@DirtiesContext
public class UserRepositoryTest {

    @Autowired
    private UserRepository userRepository;

    public void deleteAll() {
        userRepository.deleteAll();;
    }

    @Test
    public void addUserSucces() {
        deleteAll();

        User user = new User("Jonas");
        user.setPassword("123456");
        user.setRole("ROLE_USER");
        user.setEnabled(true);

        User savedUser = userRepository.save(user);

        assertEquals(savedUser.getName(), user.getName());
        assertEquals(savedUser.getPassword(), user.getPassword());
        assertEquals(savedUser.getRole(), user.getRole());
    }

    @Test(expected = Exception.class)
    public void addUserFailedNoPassword() {
        deleteAll();

        User user = new User("Jonas");
        user.setRole("ROLE_USER");
        user.setEnabled(true);

        User savedUser = userRepository.save(user);
    }

    @Test(expected = Exception.class)
    public void addUserFailedNoName() {
        deleteAll();

        User user = new User();
        user.setPassword("Test1234");

        userRepository.save(user);
    }

    @Test
    public void getUserByUserName() {
        deleteAll();

        User user = new User("Jonas");
        user.setPassword("123456");

        User savedUser = userRepository.save(user);
        User databaseUser = userRepository.getUserByUsername("Jonas");

        assertEquals(savedUser.getName(), databaseUser.getName());
        assertEquals(savedUser.getId(), databaseUser.getId());
        assertEquals(savedUser.getPassword(), databaseUser.getPassword());
    }

}
