package com.example.helppet.Controlador;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.example.helppet.R;

import org.w3c.dom.Text;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link Fragment_Info#newInstance} factory method to
 * create an instance of this fragment.
 */
public class Fragment_Info extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters


    private TextView chipo,castra,sexo,raza,espe,edad;
    public Fragment_Info() {

    }



    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment Fragment_Info.
     */
    // TODO: Rename and change types and number of parameters
    public static Fragment_Info newInstance(String param1, String param2) {
        Fragment_Info fragment = new Fragment_Info();
        Bundle args = new Bundle();

        fragment.setArguments(args);
        return fragment;
    }
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(getArguments()!=null){

        }

    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view= inflater.inflate(R.layout.fragment__info, container, false);
        if(getArguments()!=null){
            chipo=(TextView)view.findViewById(R.id.Mchip);
            castra=(TextView)view.findViewById(R.id.MCastrado);
            sexo=(TextView)view.findViewById(R.id.Msexo);
            raza=(TextView)view.findViewById(R.id.Mraza);
            espe=(TextView)view.findViewById(R.id.Mespecie);
            edad=(TextView)view.findViewById(R.id.Mnaixement);
            //llenar campos
            String respuest= this.getArguments().getString("respuesta");
            String [] campos= respuest.split("<br>");
            chipo.setText(campos[0]);
            castra.setText(campos[5]);
            sexo.setText(campos[4]);
            raza.setText(campos [3]);
            espe.setText(campos[2]);
            edad.setText(campos[1]);

        }

        return view;
    }




}