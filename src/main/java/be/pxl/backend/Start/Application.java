package be.pxl.backend.start;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.*;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;

import javax.sql.DataSource;
import java.util.stream.Stream;

/**
 * Created by Jonas on 7/10/16.
 */

@SpringBootApplication
@EnableAspectJAutoProxy
@EnableJpaRepositories(basePackages = "be.pxl.backend.repositories")
@EntityScan(basePackages = "be.pxl.backend.models")
@ComponentScan(basePackages = { "be.pxl.backend.restcontrollers", "be.pxl.backend.repositories", "be.pxl.backend.models", "be.pxl.backend.services", "be.pxl.backend.aop"})
@EnableGlobalMethodSecurity(securedEnabled = true)
public class Application {

    public static void main(String []args) {
        ApplicationContext ctx = SpringApplication.run(Application.class, args);
        Stream.of(ctx.getBeanDefinitionNames()).sorted().forEach(System.out::println);
    }

    @Autowired
    public void configureSecurity(AuthenticationManagerBuilder auth, DataSource ds) throws Exception {
        auth.jdbcAuthentication().passwordEncoder(new BCryptPasswordEncoder()).dataSource(ds)
                .usersByUsernameQuery("select name, password, enabled from Users where name = ?")
                .authoritiesByUsernameQuery("select name, role from Users where name = ?");
    }
}
