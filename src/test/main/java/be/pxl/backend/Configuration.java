package be.pxl.backend;

import be.pxl.backend.repositories.UserRepository;
import org.mockito.Mockito;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Primary;
import org.springframework.context.annotation.Profile;

/**
 * Created by Jonas on 6/11/16.
 */

@Profile("tests")
@org.springframework.context.annotation.Configuration
public class Configuration {

    @Bean
    @Primary
    public UserRepository userRepository() {
        return Mockito.mock(UserRepository.class);
    }

}
