<?php

//Database seeder: Session table
//This inserts basic data into the sessions table

class SessionTableSeeder extends Seeder {

  public function run()
  {
    Session::create(
      array(
        'league_id' => '1',
        'league_name' => 'Thursday Night Merchants',
        'date' => '4/16/15'
      )
    );

    Session::create(
      array(
        'league_id' => '1',
        'league_name' => 'Thursday Night Merchants',
        'date' => '4/9/15'
      )
    );
    
    Session::create(
      array(
        'league_id' => '1',
        'league_name' => 'Thursday Night Merchants',
        'date' => '4/2/15'
      )
    );
  }
}