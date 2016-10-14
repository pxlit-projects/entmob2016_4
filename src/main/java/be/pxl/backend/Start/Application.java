package be.pxl.backend.Start;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.*;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

import java.util.stream.Stream;

/**
 * Created by Jonas on 7/10/16.
 */

@SpringBootApplication
@EnableJpaRepositories(basePackages = "be.pxl.backend.repositories")
@EntityScan(basePackages = "be.pxl.backend.models")
@ComponentScan(basePackages = { "be.pxl.backend.restcontrollers", "be.pxl.backend.repositories", "be.pxl.backend.models", "be.pxl.backend.services"})
public class Application {

    public static void main(String []args) {
        ApplicationContext ctx = SpringApplication.run(Application.class, args);
        Stream.of(ctx.getBeanDefinitionNames()).sorted().forEach(System.out::println);
    }
}
