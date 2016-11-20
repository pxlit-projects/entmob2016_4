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
        creation = new Creation();
        creation.setDate(new Date());
    }

    @AfterReturning(value = "execution(* be.pxl.backend.services.UserService.addUser(..)))", returning = "user")
    public void afterReturning(User user) {
        creation.setUserId(user.getId());
        creation.setSucces(true);
        creationRepository.save(creation);
        creation = null;
    }

    @AfterThrowing(value = "execution(* be.pxl.backend.services.UserService.addUser(..))", throwing = "ex")
    public void afterThrowing(Exception ex) {
        creation.setErrorMessage(ex.getMessage());
        creation.setSucces(false);
        creationRepository.save(creation);
        creation = null;
    }

}
