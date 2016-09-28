<?php

class SessionController extends BaseController {
	
	public function showSessions()
	{
        $sessions = SessionModel::all(); //needs model file
        //return $sessionsValues;
        return View::make('sessions', array('sessions' => $sessions));
	}
	
	public function showSessionsById($id)
	{
	    $sessions = DB::table('sessions')
	                    ->where('league_id', '=', $id)
	                    ->get();
	                    
        return View::make('sessions', array('sessions' => $sessions));
	}
	
	
	public function insertSession()
	{
	    return View::make('insertSession');
	}
	
	
	public function postInsertSession()
	{
        $input = Input::all();
    
        $rules = array(
            'league_id' => 'required',
            'league_name' => 'required',
            'date' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
        if($validator->fails()) {					
    	   return Redirect::to('insertSession')->withErrors($validator)->withInput();
        }
        
        $inputLeagueId = Input::get('league_id');
        $inputLeagueName = Input::get('league_name');
        $inputDate = Input::get('date');
        
        
        DB::table('sessions')->insert(array(
                                        'league_id' => $inputLeagueId,
                                        'league_name' => $inputLeagueName,
                                        'date' => $inputDate));
        
        
        //return View::make('home');
        return Redirect::to('sessions')->with('message', 'Created new Record in Sessions table');
	}
	
	public function updateSession($id, $leagueId, $leagueName, $date)
	{
	    	    return View::make('updateSession')->with('id', $id)
	                                     ->with('leagueId', $leagueId)
	                                     ->with('leagueName', $leagueName)
	                                     ->with('date', $date);
	}
	
	public function putUpdateSession()
	{
	    $input = Input::all();
	    
	    $rules = array(
            'league_name' => 'required',
            'date' => 'required'
        );
        
        $validator = Validator::make($input, $rules);
        
        if($validator->fails()) {					
    	   return Redirect::to('updateSession')->withErrors($validator)->withInput();
        }
        
        $id = Input::get('id');
        $leagueName = Input::get('league_name');
        $date = Input::get('date');
        
        DB::table('sessions')->where('id', '=', $id)
                            ->update(array('league_name' => $leagueName,
                                            'date' => $date));
	    
	    return Redirect::to('sessions')->with('message', 'Updated Record in Sessions table');
	}
	
	public function deleteSession($id)
	{
	    return View::make('deleteSession')->with('id', $id);
	}
	
	public function postDeleteSession($id)
	{
	    DB::table('sessions')->where('id', '=', $id)
	                        ->delete();
	                        
	   return Redirect::to('sessions')->with('message', 'Deleted ID '.$id.' from Sessions table');
	}
	    
	
}