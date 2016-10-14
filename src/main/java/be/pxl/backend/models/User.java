package be.pxl.backend.models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */

@Entity
public class User implements Serializable {

    @Id
    @GeneratedValue
    @Column(name = "Id")
    private int id;

    @Column(name = "Username")
    private String username;

    @Column(name = "Password")
    private String password;

    @OneToMany(mappedBy = "user")
    private Set<Session> sessions = new HashSet<Session>();

    public int getId() {
        return id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

}
