<?php

//Database seeder: League table
//This inserts basic data into the leagues table

class LeagueTableSeeder extends Seeder {

  public function run()
  {
    League::create(
      array(
        'name' => 'Thursday Night Merchants',
        'date' => '2014-2015'
      )
    );

    League::create(
      array(
        'name' => 'Saturday Mixed',
        'date' => '2014-2015'
      )
    );
    
    League::create(
      array(
        'name' => 'Tuesday Night',
        'date' => '2014-2015'
      )
    );
  }
}