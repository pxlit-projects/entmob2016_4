package be.pxl.backend.repositories;

import be.pxl.backend.models.Pressure;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
public interface PressureRepository extends CrudRepository<Pressure, Integer> {

    @Query(value = "select p from Pressure p")
    List<Pressure> getPressuresForSession(int id);

}
