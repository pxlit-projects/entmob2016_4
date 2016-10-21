package be.pxl.backend.aop;

import be.pxl.backend.models.Creation;
import be.pxl.backend.models.User;
import be.pxl.backend.repositories.CreationRepository;
import org.aspectj.lang.annotation.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.Date;

/**
 * Created by Jonas on 21/10/16.
 */
@Component
@Aspect
public class UserAop {

    private Creation creation;

    @Autowired
    private CreationRepository creationRepository;

    @Before(value = "execution(* be.pxl.backend.services.UserService.addUser(..))")
    public void before() {
        System.out.println("addUser wil be called");
        creation = new Creation();
    }

    @AfterReturning(value = "execution(* be.pxl.backend.services.UserService.addUser(..)))", returning = "user")
    public void afterReturning(User user) {
        System.out.println("User returned :" + user.getName() + user.getId());
        creation.setUserId(user.getId());
        creation.setCreated(new Date());
        creation.setSucces(true);
        creationRepository.save(creation);
        creation = null;
    }

    @AfterThrowing(value = "execution(* be.pxl.backend.services.UserService.addUser(..))", throwing = "ex")
    public void afterThrowing(Exception ex) {
        System.out.println("error " + ex.getMessage());
        creation.setErrorMessage(ex.getMessage());
        creation.setCreated(new Date());
        creation.setSucces(false);
        creationRepository.save(creation);
        creation = null;
    }

    @After(value = "execution(* be.pxl.backend.services.UserService.addUser(..))")
    public void after() {
        System.out.println("addUser has been called");
    }

}
