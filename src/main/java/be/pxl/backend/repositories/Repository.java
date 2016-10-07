package be.pxl.backend.repositories;

import javax.persistence.EntityManagerFactory;
import javax.persistence.PersistenceUnit;

/**
 * Created by Jonas on 7/10/16.
 */
public class Repository {

    protected EntityManagerFactory emf;

    @PersistenceUnit
    public void addPeristenceUnit(EntityManagerFactory emf) {
        this.emf = emf;
    }
}
