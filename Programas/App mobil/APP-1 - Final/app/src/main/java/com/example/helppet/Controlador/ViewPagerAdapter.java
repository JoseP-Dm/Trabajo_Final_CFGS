package com.example.helppet.Controlador;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.Lifecycle;
import androidx.viewpager2.adapter.FragmentStateAdapter;

import java.util.ArrayList;

public class ViewPagerAdapter extends FragmentStateAdapter {


        ArrayList<Fragment> fragmentos= new ArrayList<>();
        public ViewPagerAdapter(@NonNull FragmentManager fragmentManager, @NonNull Lifecycle lifecycle) {
            super(fragmentManager, lifecycle);
        }

        @NonNull
        @Override
        public Fragment createFragment(int position) {
            Fragment frag = new Fragment();
            return fragmentos.get(position);

        }

        @Override
        public int getItemCount() {
            return fragmentos.size();
        }
        public void addFragment(Fragment fragment){
            fragmentos.add(fragment);
        }
    }


