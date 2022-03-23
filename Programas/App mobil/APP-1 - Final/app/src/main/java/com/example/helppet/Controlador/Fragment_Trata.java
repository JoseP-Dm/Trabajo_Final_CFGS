package com.example.helppet.Controlador;

import android.os.Bundle;

import androidx.annotation.StringRes;
import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.helppet.R;



/**
 * A simple {@link Fragment} subclass.
 * Use the {@link Fragment_Trata#newInstance} factory method to
 * create an instance of this fragment.
 */
public class Fragment_Trata extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    public Fragment_Trata() {

    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment Fragment_Trata.
     */
    // TODO: Rename and change types and number of parameters
    public static Fragment_Trata newInstance(String param1, String param2) {
        Fragment_Trata fragment = new Fragment_Trata();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);
        return fragment;
    }
    public TextView veterinario,fecha_caso, fecha_revision,Observacion,tratamiento, peso ,medicamento,enfermedad;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {

        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View view= inflater.inflate(R.layout.fragment__trata, container, false);
        if(getArguments()!=null){
            veterinario=(TextView)view.findViewById(R.id.Cveterinario);
            fecha_caso=(TextView)view.findViewById(R.id.CData_Registre);
            fecha_revision=(TextView)view.findViewById(R.id.CData_Revisio);
            Observacion=(TextView)view.findViewById(R.id.CObservacio);
            tratamiento=(TextView)view.findViewById(R.id.Ctractament);
            peso=(TextView)view.findViewById(R.id.CPes);
            medicamento=(TextView)view.findViewById(R.id.CMedicament);
            enfermedad=(TextView)view.findViewById(R.id.CEnfermetat);
            //llenar campos
            String respuest= this.getArguments().getString("respuesta");
            String [] campos= respuest.split("<br>");
            veterinario.setText(campos[0]);
            fecha_caso.setText(campos[1]);
            fecha_revision.setText(campos[2]);
            Observacion.setText(campos [3]);
            peso.setText(campos[4]);
            tratamiento.setText(campos[5]);
            medicamento.setText(campos[6]);
            enfermedad.setText(campos[7]);
        }else{
            veterinario=(TextView)view.findViewById(R.id.Cveterinario);
            fecha_caso=(TextView)view.findViewById(R.id.CData_Registre);
            fecha_revision=(TextView)view.findViewById(R.id.CData_Revisio);
            Observacion=(TextView)view.findViewById(R.id.CObservacio);
            tratamiento=(TextView)view.findViewById(R.id.Ctractament);
            peso=(TextView)view.findViewById(R.id.CPes);
            medicamento=(TextView)view.findViewById(R.id.CMedicament);
            enfermedad=(TextView)view.findViewById(R.id.CEnfermetat);
            veterinario.setText("Veterinario que reviso al animal");
            fecha_caso.setText("Fecha");
            fecha_revision.setText("Fecha");
            Observacion.setText("");
            Observacion.setHint("Observaciones");
            peso.setText("Peso");
            tratamiento.setText("");
            tratamiento.setHint("Tratamiento a seguir");
            medicamento.setText("Medicamentos");
            enfermedad.setText("Enfermedad");
        }
        return view;
    }


 }