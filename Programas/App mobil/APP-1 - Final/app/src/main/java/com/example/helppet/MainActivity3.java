package com.example.helppet;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.viewpager2.widget.ViewPager2;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.helppet.Controlador.Fragment_Info;
import com.example.helppet.Controlador.Fragment_Trata;
import com.example.helppet.Controlador.ViewPagerAdapter;
import com.google.android.material.tabs.TabLayout;
import com.google.android.material.tabs.TabLayoutMediator;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class MainActivity3 extends AppCompatActivity {
    ViewPager2 viewPager2;
    ViewPagerAdapter madapter;
    private Spinner Spin, Spin1;
    private boolean control_casos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);
        control_casos=false;
        if (getSupportActionBar() != null) {
            getSupportActionBar().hide();
        }
        final String usuario = getIntent().getStringExtra("usuario");
        Spin = (Spinner) findViewById(R.id.spinner);
        viewPager2 = (ViewPager2) findViewById(R.id.viewpager2);
        madapter = new ViewPagerAdapter(getSupportFragmentManager(), getLifecycle());
        //addfragment
        madapter.addFragment(new Fragment_Info());//0
        madapter.addFragment(new Fragment_Trata());//1
       // madapter.addFragment(new Fragment_Alertas());//2
        viewPager2.setAdapter(madapter);
        TabLayout tabLayout = (TabLayout) findViewById(R.id.tablayout);

        new TabLayoutMediator(tabLayout, viewPager2, new TabLayoutMediator.TabConfigurationStrategy() {
            @Override
            public void onConfigureTab(@NonNull TabLayout.Tab tab, int position) {
                switch (position) {
                    case 0:
                        tab.setText("Informacion");
                        break;
                    case 1:
                        tab.setText("Tratamiento");
                        break;
                  /*  case 2:
                        tab.setText("Alertas");
                        break;*/
                }

            }
        }).attach();
        StringRequest request = new StringRequest(Request.Method.POST, "https://hypogastric-backs.000webhostapp.com/llenar_spinner.php", new Response.Listener<String>() {

            @Override
            public void onResponse(String response) {
                String[] mascotapre = response.split("<br>");
                ArrayList<String> mascotas = new ArrayList<String>();
                System.out.println(response);

                for (int i = 0; i < mascotapre.length; i++) {
                 mascotas.add(mascotapre[i]);
                    System.out.println(i);
                }

                ArrayAdapter<String> adaptar = new ArrayAdapter<String>(MainActivity3.this,android.R.layout.simple_spinner_item,mascotas);
                runOnUiThread(new Runnable() {
                    @Override
                    public void run() {
                        Spin.setAdapter(adaptar);
                    }
                });
            }


        }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
                Toast.makeText(MainActivity3.this, "No s'ha pogut recollir la informació", Toast.LENGTH_SHORT).show();
            }
        }) {
            @Override
            protected Map<String, String> getParams() throws AuthFailureError {
                Map<String, String> params = new HashMap<>();
                params.put("username", usuario);
                return params;
            }
        };
        Volley.newRequestQueue(this).add(request);


    }

    public void select(View view) {
        String seleccio = Spin.getSelectedItem().toString();
        if (seleccio.equals("")) {
            Toast.makeText(this, "Mascota no escollida", Toast.LENGTH_SHORT).show();
        } else {
            viewPager2.setCurrentItem(0);
            String chip1 = Spin.getSelectedItem().toString();
            String[] chip2 = chip1.split(" ");
            String chip3 = chip2[0];
            //llenar spinner de casos
            StringRequest request = new StringRequest(Request.Method.POST, "https://hypogastric-backs.000webhostapp.com/llenar_spinner_casos.php", new Response.Listener<String>() {

                @Override
                public void onResponse(String response) {
                    String[] casos = response.split("<br>");
                    ArrayList<String> casos1 = new ArrayList<String>();
                    for (int i = 0; i < casos.length; i++) {
                        casos1.add(casos[i]);
                    }
                    Spin1 = (Spinner) findViewById(R.id.Spin2);
                    ArrayAdapter<String> adaptar = new ArrayAdapter<String>(MainActivity3.this, android.R.layout.simple_spinner_item, casos1);
                    runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            Spin1.setAdapter(adaptar);
                        }
                    });
                    control_casos=true;

                }

            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {

                }
            }) {
                @Override
                protected Map<String, String> getParams() throws AuthFailureError {
                    Map<String, String> params = new HashMap<>();
                    params.put("chip", chip3);
                    return params;
                }
            };
            Volley.newRequestQueue(this).add(request);

            //pasar datos a fragment
            StringRequest request1 = new StringRequest(Request.Method.POST, "https://hypogastric-backs.000webhostapp.com/llenar_info.php", new Response.Listener<String>() {

                @Override
                public void onResponse(String response1) {
                    //cargar el usuario
                    Fragment_Info fra = new Fragment_Info();
                    Bundle respondido = new Bundle();
                    respondido.putString("respuesta", response1);
                    fra.setArguments(respondido);
                    FragmentManager fragmentManager = getSupportFragmentManager();
                    FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                    fragmentTransaction.replace(R.id.info, fra);
                    fragmentTransaction.commit();


                }

            }, new Response.ErrorListener() {
                @Override
                public void onErrorResponse(VolleyError error) {

                }
            }) {
                @Override
                protected Map<String, String> getParams() throws AuthFailureError {
                    Map<String, String> params = new HashMap<>();
                    params.put("chip", chip3);
                    return params;
                }
            };
            Volley.newRequestQueue(this).add(request1);

        }
    }

    public void casos(View view) {
            if(control_casos==true) {
                String seleccio1 = Spin1.getSelectedItem().toString();
                if (seleccio1.equals("")) {
                    Toast.makeText(this, "Cas no seleccionat", Toast.LENGTH_SHORT).show();
                } else {
                    viewPager2.setCurrentItem(1);

                    String cas1 = Spin1.getSelectedItem().toString();
                    String[] cas2 = cas1.split(" ");
                    final String[] caso = {cas2[0]};
                    //pasar datos a fragment
                    StringRequest request2 = new StringRequest(Request.Method.POST, "https://hypogastric-backs.000webhostapp.com/llenar_trata.php", new Response.Listener<String>() {

                        @Override
                        public void onResponse(String response2) {
                            Fragment_Trata frac = new Fragment_Trata();
                            Bundle respondido2 = new Bundle();
                            respondido2.putString("respuesta", response2);
                            frac.setArguments(respondido2);
                            FragmentManager fragmentManager = getSupportFragmentManager();
                            FragmentTransaction fragmentTransaction = fragmentManager.beginTransaction();
                            fragmentTransaction.replace(R.id.tra, frac);
                            fragmentTransaction.commit();
                        }

                    }, new Response.ErrorListener() {
                        @Override
                        public void onErrorResponse(VolleyError error) {

                        }
                    }) {
                        @Override
                        protected Map<String, String> getParams() throws AuthFailureError {
                            Map<String, String> params = new HashMap<>();
                            params.put("cas", caso[0]);
                            return params;
                        }
                    };
                    Volley.newRequestQueue(this).add(request2);


                }


            }
    }

}