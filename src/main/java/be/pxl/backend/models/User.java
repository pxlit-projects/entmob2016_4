package be.pxl.backend.models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */

@Entity
@Table(name = "Users")
public class User implements Serializable {

    @Id
    @GeneratedValue
    private int id;

    private String firstName;

    private String lastName;

    @Column(nullable = false)
    private String name;

    @Column(nullable = false)
    private String password;

    private String role;

    private Boolean enabled;

    @OneToMany(mappedBy = "user")
    private Set<Session> sessions = new HashSet<Session>();

    public int getId() {
        return id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public Boolean getEnabled() {
        return enabled;
    }

    public void setEnabled(Boolean enabled) {
        this.enabled = enabled;
    }

    public Set<Session> getSessions() {
        return sessions;
    }

    public void setSessions(Set<Session> sessions) {
        this.sessions = sessions;
    }
}
