<?php

//Database seeder: This runs the other database seeders
//					to input data into the database

class DatabaseSeeder extends Seeder {

	/**
	 * Run the database seeds.
	 *
	 * @return void
	 */
	public function run()
	{
		Eloquent::unguard();

		//$this->call('LeagueTableSeeder');
		$this->call('SessionTableSeeder');
	}

}
