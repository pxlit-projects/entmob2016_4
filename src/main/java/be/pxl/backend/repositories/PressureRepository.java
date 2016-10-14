package be.pxl.backend.repositories;

import be.pxl.backend.models.Pressure;

import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository
public interface PressureRepository extends CrudRepository<Pressure, Integer> {

    List<Pressure> getPressuresForSession(int id);

}
