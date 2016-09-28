<?php

class LeagueController extends BaseController {

	public function get_id()
	{
		//????????
	}
	
	public function showLeagues()
	{
        $leagues = League::all();
        //return $leagues;
        return View::make('leagues', array('leagues' => $leagues));
	}
	
	public function showLeagueId($id)
	{
	    $league = League::find($id);
	    
	    return 'Here it is' .$league;
	}
	
	
	
	public function showOptions($id)
	{
	    Form::button('View');
	    Form::button('Update');
	    Form::button('Delete');
	    //THIS DOESN'T WORK YET
	}
	
	public function insertLeague()
	{
	    return View::make('insertLeague');
	}
	
	public function postInsertLeague()
	{
	    $input = Input::all();
        
        $rules = array(
            'name' => 'required',
            'date' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
        if($validator->fails()) {					
    	   return Redirect::to('insertLeague')->withErrors($validator)->withInput();
        }
        
        //DB::table('leagues')->insert($input);
        
        $inputName = Input::get('name');
        $inputDate = Input::get('date');
        
        //$testing = Input::get('name');
        
        DB::table('leagues')->insert(array('name' => $inputName,
                                      'date' => $inputDate));
        
        //return $testing;
        //return View::make('home');
        return Redirect::to('leagues')->with('message', 'Created new Record in Leagues table');
        //return Redirect::route('/');
        //return redirect('/')->with('message', 'League Added!');
	}
	
	public function updateLeague($id, $name, $date)
	{
	    //return View::make('updateLeague')->with('league', League::find('$id'));
	    
	    //fill in the updateLeague page with name and date
	    return View::make('updateLeague')->with('id', $id)
	                                     ->with('name', $name)
	                                     ->with('date', $date);
	}
	
	public function putUpdateLeague()
	{
	    $input = Input::all();
	    
	    $rules = array(
            'name' => 'required',
            'date' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
        if($validator->fails()) {					
    	   return Redirect::to('updateLeague')->withErrors($validator)->withInput();
        }
        
        $id = Input::get('id');
        $name = Input::get('name');
        $date = Input::get('date');
        
        DB::table('leagues')->where('id', '=', $id)
                            ->update(array('name' => Input::get('name'),
                                            'date' => Input::get('date')));
	    
	    return Redirect::to('leagues')->with('message', 'Updated Record in Leagues table');
	}
	
	public function deleteLeague($id)
	{
	    return View::make('deleteLeague')->with('id', $id);
	}
	
	public function postDeleteLeague($id)
	{
	    DB::table('leagues')->where('id', '=', $id)
	                        ->delete();
	                        
	   return Redirect::to('leagues')->with('message', 'Deleted ID '.$id.' from Leagues table');
	}

}
