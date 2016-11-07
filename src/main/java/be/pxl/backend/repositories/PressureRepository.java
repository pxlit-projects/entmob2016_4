package be.pxl.backend.repositories;

import be.pxl.backend.models.Pressure;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository
public interface PressureRepository extends CrudRepository<Pressure, Integer> {

    @Query(value = "select p from Pressure p where p.session.id =:id")
    List<Pressure> getPressuresForSession(@Param(value = "id") int id);

    @Modifying
    @Query(value = "delete from Pressure p where p.session.id =:id")
    void deleteForSession(@Param(value = "id") int id);
}
