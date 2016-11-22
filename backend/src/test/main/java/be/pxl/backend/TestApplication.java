package be.pxl.backend;

import be.pxl.backend.jms.JmsSender;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.mockito.Mockito;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.orm.jpa.EntityScan;
import org.springframework.context.ApplicationContext;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.ComponentScan;
import org.springframework.context.annotation.EnableAspectJAutoProxy;
import org.springframework.context.annotation.Primary;
import org.springframework.data.jpa.repository.config.EnableJpaRepositories;

/**
 * Created by Jonas on 19/11/16.
 */
@SpringBootApplication
@EnableAspectJAutoProxy
@EnableJpaRepositories(basePackages = "be.pxl.backend.repositories")
@EntityScan(basePackages = "be.pxl.backend.models")
@ComponentScan(basePackages = { "be.pxl.backend.restcontrollers", "be.pxl.backend.repositories", "be.pxl.backend.models", "be.pxl.backend.services", "be.pxl.backend.aop", "be.pxl.backend.jms"})
public class TestApplication {

    public static void main(String []args) throws Exception {
        ApplicationContext ctx = SpringApplication.run(Application.class, args);
        //Stream.of(ctx.getBeanDefinitionNames()).sorted().forEach(System.out::println);
    }

}
