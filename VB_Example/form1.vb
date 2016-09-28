'------------------------------------------------------------
'-                File Name : Form1.vb                      -
'-                Part of Project: Assignment 7             -
'------------------------------------------------------------
'-                Written By: Eric DeSmet                   -
'-                Written On: (2-12-14) - (3-25-14)         -
'------------------------------------------------------------
'- File Purpose:                                            -
'- This file contains the main application form where the   -
'- user will be able to navigate a restaurant menu.
'------------------------------------------------------------
'- Program Purpose:                                         -
'- The user                                                 -
'- will be able to see the what each dish comes with, and   -
'- what each prepped item has in it. The user will also be  -
'- able to add dishes, prepped items, or raw ingredients as -
'- well as be able to add and remove them from each dish.   -                                                         -
'-                                                          -
'------------------------------------------------------------
'- Global Variable Dictionary (not alphabetically):         -
'- rawItems - list of raw items (bottom level)              -
'- preppedItems - dictionary(of string, rawItems)           -
'- dishes - dictionary(of string, preppeditems(of string, rawItems))
'------------------------------------------------------------

Public Class frmMenu

    Dim rawItems As New List(Of String)
    Dim preppedItems As New Dictionary(Of String, List(Of String))
    Dim dishes As New Dictionary(Of String, Dictionary(Of String, List(Of String)))

    '------------------------------------------------------------
    '-                Subprogram Name: frmMenu_Load             -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the main form is loaded–
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------
    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rawItems = New List(Of String) From {"Beef Patty", "Bun", "Ketchup", "Mustard", "Lettuce", "Tomatoes", _
                                             "Pickles", "Cheese", "Glass", "Plate", "Chicken", "Salad", "Water", _
                                             "Coloring", "Dressing"}


        'make sure these are always in the correct order, or they wont work.

        'prepared item; key is item, value is list of items, 0 based
        preppedItems.Add("Hamburger", New List(Of String))
        preppedItems("Hamburger").Add("Bun")
        preppedItems("Hamburger").Add("Beef Patty")
        preppedItems("Hamburger").Add("Ketchup")
        preppedItems("Hamburger").Add("Lettuce")
        preppedItems("Hamburger").Add("Tomatoes")
        preppedItems("Hamburger").Add("Mustard")
        preppedItems("Hamburger").Add("Pickles")
        preppedItems("Hamburger").Add("Onions")
        preppedItems("Hamburger").Add("Cheese")

        preppedItems.Add("Fries", New List(Of String))
        preppedItems("Fries").Add("Potatoes")
        preppedItems("Fries").Add("Salt")

        preppedItems.Add("Soft Drink", New List(Of String))
        preppedItems("Soft Drink").Add("Water")
        preppedItems("Soft Drink").Add("Sugar")
        preppedItems("Soft Drink").Add("Coloring")

        preppedItems.Add("Chicken Salad", New List(Of String))
        preppedItems("Chicken Salad").Add("Chicken")
        preppedItems("Chicken Salad").Add("Salad")
        preppedItems("Chicken Salad").Add("Tomatoes")
        preppedItems("Chicken Salad").Add("Dressing")

        dishes.Add("Hamburger Platter", New Dictionary(Of String, List(Of String)))
        dishes("Hamburger Platter").Add("Hamburger", preppedItems("Hamburger"))
        dishes("Hamburger Platter").Add("Fries", preppedItems("Fries"))
        dishes("Hamburger Platter").Add("Soft Drink", preppedItems("Soft Drink"))

        dishes.Add("Chicken Salad Platter", New Dictionary(Of String, List(Of String)))
        dishes("Chicken Salad Platter").Add("Chicken Salad", preppedItems("Chicken Salad"))


        'Initial filling in the list boxes with default menu items
        For Each item As String In dishes.Keys
            lsbDishes.Items.Add(item)
        Next

        For Each item As String In preppedItems.Keys
            lsbPreppedItems.Items.Add(item)
        Next

        For i As Integer = 0 To rawItems.Count - 1
            lsbRawIngredients.Items.Add(rawItems(i))
        Next


        lsbDishes.Sorted = True
        lsbPreppedItems.Sorted = True
        lsbRawIngredients.Sorted = True
        lsbSelectedIngredients.Sorted = True
        lsbSelectedPrepped.Sorted = True

        '***************************************************************
        'NEW DRAG/DROP STUFF FOR ASSIGNMENT 7
        '***************************************************************
        lsbSelectedPrepped.AllowDrop = True
        lsbPreppedItems.AllowDrop = True
        lsbSelectedIngredients.AllowDrop = True
        lsbRawIngredients.AllowDrop = True


    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbDishes_SelectedIndexChanged    -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks a     –
    '- list item in lsbDishes. This changes the values in the   -
    '- lsbSelectedPrepped so it shows the correct items in the  -
    '- selected dish
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub lsbDishes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbDishes.SelectedIndexChanged
        lsbSelectedPrepped.Items.Clear()
        For Each item As String In dishes(lsbDishes.SelectedItem).Keys
            lsbSelectedPrepped.Items.Add(item)
        Next
    End Sub


    '------------------------------------------------------------
    '-   Subprogram Name: lsbPreppedItems_SelectedIndexChanged  -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks a     –
    '- list item in lsbPreppedItems. This changes the values in the-
    '- lsbSelectedRawIngredients so it shows the correct items  -
    '- in the selected prepped item                             -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub lsbPreppedItems_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbPreppedItems.SelectedIndexChanged
        lsbSelectedIngredients.Items.Clear()
        If preppedItems.ContainsKey(lsbPreppedItems.SelectedItem) Then
            For i As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                lsbSelectedIngredients.Items.Add(preppedItems(lsbPreppedItems.SelectedItem).Item(i))
                '(Key: selected item, value: i - length)
            Next
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnAddNewRaw_Click                -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- AddNewRaw button. This will add the (valid) value from   -
    '- txtAddRaw into the list                                  -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnAddNewRaw_Click(sender As Object, e As EventArgs) Handles btnAddNewRaw.Click
        Dim strNewRaw As String
        strNewRaw = txtAddRaw.Text
        If String.IsNullOrEmpty(strNewRaw) Then
            MessageBox.Show("Error! Add Raw Textbox is empty! Cannot add nothing!")
        Else
            strNewRaw = Char.ToUpper(strNewRaw(0)) & strNewRaw.Substring(1)
            For x As Integer = 0 To rawItems.Count - 1
                If strNewRaw = rawItems(x) Then
                    MessageBox.Show("Error! Raw Ingredient already exists!")
                    Exit Sub
                End If
            Next

            rawItems.Add(strNewRaw)
            lsbRawIngredients.Items.Clear()
            For i As Integer = 0 To rawItems.Count - 1
                lsbRawIngredients.Items.Add(rawItems(i))
            Next
            txtAddRaw.Text = ""
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnAddNewPrepped_Click            -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- AddNewPrepped button. This will take the (valid) value   -
    '- from txtAddPrepped and add it to the dictionary          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnAddNewPrepped_Click(sender As Object, e As EventArgs) Handles btnAddNewPrepped.Click
        Dim strNewPrepped As String
        strNewPrepped = txtAddPrepped.Text
        If String.IsNullOrEmpty(strNewPrepped) Then
            MessageBox.Show("Error! Add Prepped Textbox is empty! Cannot add nothing!")
        Else
            strNewPrepped = Char.ToUpper(strNewPrepped(0)) & strNewPrepped.Substring(1)
            For Each item As String In preppedItems.Keys
                If strNewPrepped = item Then
                    MessageBox.Show("Error! Prepped Item Already Exists!")
                    Exit Sub
                End If
            Next

            preppedItems.Add(strNewPrepped, New List(Of String))
            lsbPreppedItems.Items.Clear()
            For Each item As String In preppedItems.Keys
                lsbPreppedItems.Items.Add(item)
            Next
            txtAddPrepped.Text = ""
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnAddDish_Click                  -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- AddDish button. This will take the (valid) value from    -
    '- txtAddDish and add it to the dictionary of dishes        -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnAddDish_Click(sender As Object, e As EventArgs) Handles btnAddDish.Click
        Dim strNewDish As String
        strNewDish = txtAddDish.Text
        If String.IsNullOrEmpty(strNewDish) Then
            MessageBox.Show("Error! Add Dish Textbox is empty! Cannot add nothing!")
        Else
            strNewDish = Char.ToUpper(strNewDish(0)) & strNewDish.Substring(1)
            For Each item As String In dishes.Keys
                If strNewDish = item Then
                    MessageBox.Show("Error! Dish already exists!")
                    Exit Sub
                End If
            Next

            dishes.Add(strNewDish, New Dictionary(Of String, List(Of String)))
            lsbDishes.Items.Clear()
            For Each item As String In dishes.Keys
                lsbDishes.Items.Add(item)
            Next
            txtAddDish.Text = ""
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnAddPrepped_Click               -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- AddPrepped button (top-most left arrow). Then it will    -
    '- take the selected prepped item and add it to the selected-
    '- dish                                                     -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnAddPrepped_Click(sender As Object, e As EventArgs) Handles btnAddPrepped.Click
        If lsbPreppedItems.SelectedIndex >= 0 Then
            If lsbDishes.SelectedIndex >= 0 Then
                'IF ITEM IS ALREADY THERE, CANNOT ADD******
                If lsbSelectedPrepped.Items.Contains(lsbPreppedItems.SelectedItem) Then
                    MessageBox.Show("Selected dish already contains " & lsbPreppedItems.SelectedItem & ". Try again")
                Else
                    dishes(lsbDishes.SelectedItem).Add(lsbPreppedItems.SelectedItem, New List(Of String))
                    lsbSelectedPrepped.Items.Clear()
                    For Each item In dishes(lsbDishes.SelectedItem).Keys
                        lsbSelectedPrepped.Items.Add(item)
                    Next
                End If
            Else
                MessageBox.Show("Error! Need Selected Dish to Add to!")
            End If
        Else
            MessageBox.Show("Error! Need Selected Prepped Item to Add!")
        End If

    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnRemovePrepped                  -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- RemovePrepped button (topmost right arrow). Then it will -
    '- remove the selected prepped item from the list           -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnRemovePrepped_Click(sender As Object, e As EventArgs) Handles btnRemovePrepped.Click
        If lsbSelectedPrepped.SelectedIndex >= 0 Then
            dishes(lsbDishes.SelectedItem).Remove(lsbSelectedPrepped.SelectedItem)
            lsbSelectedPrepped.Items.Clear()
            For Each item In dishes(lsbDishes.SelectedItem).Keys
                lsbSelectedPrepped.Items.Add(item)
            Next
        Else
            MessageBox.Show("Cannot remove nothing! Please select an item in the 'selected prepped' listbox to remove")
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnAddNewRaw_Click                -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- AddNewRaw button (bottom-most left arrow). Then it will  -
    '- add the raw ingredient to the selected prepped item list -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnAddIngredient_Click(sender As Object, e As EventArgs) Handles btnAddIngredient.Click
        If lsbPreppedItems.SelectedIndex >= 0 Then
            If lsbRawIngredients.SelectedIndex >= 0 Then
                If lsbSelectedIngredients.Items.Contains(lsbRawIngredients.SelectedItem) Then
                    MessageBox.Show("Selected prepped item already contains " & lsbRawIngredients.SelectedItem & ". Try again")
                Else
                    preppedItems(lsbPreppedItems.SelectedItem).Add(lsbRawIngredients.SelectedItem)
                    lsbSelectedIngredients.Items.Clear()
                    For i As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                        lsbSelectedIngredients.Items.Add(preppedItems(lsbPreppedItems.SelectedItem).Item(i))
                    Next
                End If

            Else
                MessageBox.Show("Error! Cannot add nothing! Please select a raw ingredient!")
            End If

        Else
            MessageBox.Show("Error! Cannot add a raw ingredient to nothing! Please select an ingredient")
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: btnRemoveIngredient_Click         -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (2-12-14) - (2-18-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user clicks the   –
    '- RemoveIngredient button (bottom-most right arrow). It    -
    '- removes the selected raw ingredient from the selected    -
    '- prepared item                                            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (None)                                                   -
    '------------------------------------------------------------

    Private Sub btnRemoveIngredient_Click(sender As Object, e As EventArgs) Handles btnRemoveIngredient.Click
        If lsbSelectedIngredients.SelectedIndex >= 0 Then
            preppedItems(lsbPreppedItems.SelectedItem).Remove(lsbSelectedIngredients.SelectedItem)
            lsbSelectedIngredients.Items.Clear()
            For i As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                lsbSelectedIngredients.Items.Add(preppedItems(lsbPreppedItems.SelectedItem).Item(i))
            Next
        Else
            MessageBox.Show("Cannot remove nothing! Please select an item in the 'selected ingredients' listbox to remove")
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbPreppedItems_MouseMove         -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is over
    '- the lsbPreppedItems and we use this to see if the user
    '- wants to initiate drag and drop                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dropEffect                                               -
    '------------------------------------------------------------

    Private Sub lsbPreppedItems_MouseMove(sender As Object, e As MouseEventArgs) Handles lsbPreppedItems.MouseMove
        Dim dropEffect As DragDropEffects

        If e.Button = Windows.Forms.MouseButtons.Left Then
            dropEffect = lsbPreppedItems.DoDragDrop(lsbPreppedItems.SelectedItem.ToString(), _
                                                    DragDropEffects.Copy)
        End If

    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedPrepped)DragDrop       -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the drag and drop
    '- operation is completed (mouse is let go over the listbox)-
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dataString                                               -
    '------------------------------------------------------------

    Private Sub lsbSelectedPrepped_DragDrop(sender As Object, e As DragEventArgs) Handles lsbSelectedPrepped.DragDrop
        'Dim testData As String = Convert.ToString(e.Data)
        Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

        If lsbDishes.SelectedIndex >= 0 Then
            For Each item In dishes(lsbDishes.SelectedItem).Keys
                If item = dataString Then
                    MessageBox.Show("Error! " & item & " already exists!")
                    Exit Sub
                End If
            Next
            dishes(lsbDishes.SelectedItem).Add(dataString, preppedItems(dataString))
            lsbSelectedPrepped.Items.Clear()
            For Each item In dishes(lsbDishes.SelectedItem).Keys
                lsbSelectedPrepped.Items.Add(item)
            Next
        Else
            MessageBox.Show("Error! Dish not selected! Cannot add prepped item to nothing!")
        End If

    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedPrepped_DragEnter      -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user drags an item
    '- over the lsbSelectedPrepped                              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- (none)                                                   -
    '------------------------------------------------------------

    Private Sub lsbSelectedPrepped_DragEnter(sender As Object, e As DragEventArgs) Handles lsbSelectedPrepped.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedPrepped_MouseMove      -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is over
    '- the lsbSelectedPrepped and we use this to see if the user
    '- wants to initiate drag and drop                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dropEffect                                               -
    '------------------------------------------------------------

    Private Sub lsbSelectedPrepped_MouseMove(sender As Object, e As MouseEventArgs) Handles lsbSelectedPrepped.MouseMove
        Dim dropEffect As DragDropEffects

        If e.Button = Windows.Forms.MouseButtons.Left Then
            dropEffect = lsbPreppedItems.DoDragDrop(lsbSelectedPrepped.SelectedItem.ToString(), _
                                                    DragDropEffects.Copy)
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbPreppedItems_DragDrop          -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the drag and drop is
    '- completed. dropped over the lsbpreppeditems              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dataString                                               -
    '------------------------------------------------------------

    Private Sub lsbPreppedItems_DragDrop(sender As Object, e As DragEventArgs) Handles lsbPreppedItems.DragDrop
        Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

        If lsbDishes.SelectedIndex >= 0 Then
            dishes(lsbDishes.SelectedItem).Remove(dataString) ', preppedItems(dataString))
            lsbSelectedPrepped.Items.Clear()
            For Each item In dishes(lsbDishes.SelectedItem).Keys
                lsbSelectedPrepped.Items.Add(item)
            Next
        Else
            MessageBox.Show("Error! Dish not selected! Cannot add prepped item to nothing!")
        End If

    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbPreppedItems_DragEnter         -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is dragging
    '- over lsbpreppeditems. only shows the copy mouse image    -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dropEffect                                               -
    '------------------------------------------------------------

    Private Sub lsbPreppedItems_DragEnter(sender As Object, e As DragEventArgs) Handles lsbPreppedItems.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub
    '***********************************
    'drag drop for raw ingredients
    '********************************

    '------------------------------------------------------------
    '-       Subprogram Name: lsbRawIngredients_MouseMove       -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is over
    '- the lsbRawIngredients and we use this to see if the user
    '- wants to initiate drag and drop                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dropEffect                                               -
    '------------------------------------------------------------

    Private Sub lsbRawIngredients_MouseMove(sender As Object, e As MouseEventArgs) Handles lsbRawIngredients.MouseMove
        Dim dropEffect As DragDropEffects

        If e.Button = Windows.Forms.MouseButtons.Left Then
            dropEffect = lsbRawIngredients.DoDragDrop(lsbRawIngredients.SelectedItem.ToString(), _
                                                    DragDropEffects.Copy)
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedIngredients_DragDrop   -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the user completes the
    '- drag drop, dropping on lsbselectedingredients            -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dataString                                               -
    '------------------------------------------------------------

    Private Sub lsbSelectedIngredients_DragDrop(sender As Object, e As DragEventArgs) Handles lsbSelectedIngredients.DragDrop
        Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

        If lsbPreppedItems.SelectedIndex >= 0 Then
            For x As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                If lsbRawIngredients.SelectedItem = preppedItems(lsbPreppedItems.SelectedItem).Item(x) Then
                    MessageBox.Show("Error! Raw ingredient already exists!")
                    Exit Sub
                End If
            Next
            preppedItems(lsbPreppedItems.SelectedItem).Add(lsbRawIngredients.SelectedItem)
            lsbSelectedIngredients.Items.Clear()
            For i As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                lsbSelectedIngredients.Items.Add(preppedItems(lsbPreppedItems.SelectedItem).Item(i))
            Next
        Else
            MessageBox.Show("Error! Prepped Item not selected! Cannot add Raw Ingredient to nothing!")
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedIngredients_DragEnter  -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is dragged
    '- over lsbselectedingredients                              -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- none                                                     -
    '------------------------------------------------------------

    Private Sub lsbSelectedIngredients_DragEnter(sender As Object, e As DragEventArgs) Handles lsbSelectedIngredients.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

    'remove from selected ingredients

    '------------------------------------------------------------
    '-       Subprogram Name: lsbSelectedIngredients_MouseMove  -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is over
    '- the lsbSelectedIngredients and we use this to see if the user
    '- wants to initiate drag and drop                          -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dropEffect                                               -
    '------------------------------------------------------------

    Private Sub lsbSelectedIngredients_MouseMove(sender As Object, e As MouseEventArgs) Handles lsbSelectedIngredients.MouseMove
        Dim dropEffect As DragDropEffects

        If e.Button = Windows.Forms.MouseButtons.Left Then
            dropEffect = lsbSelectedIngredients.DoDragDrop(lsbSelectedIngredients.SelectedItem.ToString(), _
                                                    DragDropEffects.Copy)
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbRawIngredients_DragDrop         -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the dragdrop event
    '- is completed                                             -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- dataString                                               -
    '------------------------------------------------------------

    Private Sub lsbRawIngredients_DragDrop(sender As Object, e As DragEventArgs) Handles lsbRawIngredients.DragDrop
        Dim dataString As String = e.Data.GetData(DataFormats.StringFormat)

        If lsbPreppedItems.SelectedIndex >= 0 Then
            preppedItems(lsbPreppedItems.SelectedItem).Remove(lsbSelectedIngredients.SelectedItem)
            lsbSelectedIngredients.Items.Clear()
            For i As Integer = 0 To preppedItems(lsbPreppedItems.SelectedItem).Count - 1
                lsbSelectedIngredients.Items.Add(preppedItems(lsbPreppedItems.SelectedItem).Item(i))
            Next
        Else
            MessageBox.Show("Error! cant delete nothing?")
        End If
    End Sub

    '------------------------------------------------------------
    '-       Subprogram Name: lsbRawIngredients_DragEnter       -
    '------------------------------------------------------------
    '-                Written By: Eric DeSmet                   -
    '-                Written On: (3-19-14) - (3-25-14)         -
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      -
    '-                                                          -
    '- This subroutine is called whenever the users mouse is dragged
    '- over the lsbrawingredients. changes mouse effect         -
    '------------------------------------------------------------
    '- Parameter Dictionary (in parameter order):               -
    '- sender – Identifies which particular control raised the  –
    '-          click event                                     -
    '- e – Holds the EventArgs object sent to the routine       -
    '------------------------------------------------------------
    '- Local Variable Dictionary (alphabetically):              -
    '- none                                                     -
    '------------------------------------------------------------

    Private Sub lsbRawIngredients_DragEnter(sender As Object, e As DragEventArgs) Handles lsbRawIngredients.DragEnter
        e.Effect = DragDropEffects.Copy
    End Sub

End Class