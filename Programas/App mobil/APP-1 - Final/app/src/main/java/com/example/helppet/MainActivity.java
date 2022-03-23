package com.example.helppet;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import java.util.HashMap;
import java.util.Map;

public class MainActivity extends AppCompatActivity {
    private EditText user,pass;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        user=(EditText)findViewById(R.id.usu);
        pass=(EditText)findViewById(R.id.pass);
        if (getSupportActionBar() != null) {
            getSupportActionBar().hide();
        }
    }
    public void acceder(View view) {
        final String usuario = user.getText().toString();
        final String contrasenya = pass.getText().toString();
        final String dni ="";
        Intent i = new Intent(this,MainActivity3.class);
        StringRequest request= new StringRequest(Request.Method.POST, "https://hypogastric-backs.000webhostapp.com/login.php",new Response.Listener<String>() {

                    @Override
                    public void onResponse(String response) {
                        if(response.equals("1")){
                            i.putExtra("usuario",usuario);
                            startActivity(i);
                            Toast.makeText(MainActivity.this, "Datos correctos", Toast.LENGTH_SHORT).show();
                        }else{
                            Toast.makeText(MainActivity.this, "Datos erroneos", Toast.LENGTH_SHORT).show();

                        }
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {

            }
        }){
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String,String> params= new HashMap<>();
                params.put("username",usuario);
                params.put("password",contrasenya);
                return params;
            }
        };
        Volley.newRequestQueue(this).add(request);
    }


}