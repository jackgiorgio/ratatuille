xlua.hotfix(CS.XluaText,'Init',function(self)
    self.EditionText.text = '版本2'    
    self.Operator.text = '-'	
        end) 
        
xlua.hotfix(CS.XluaText,'Add',function(self)
    local num = tonumber(self.input1.text) - tonumber(self.input2.text)	
        self.Anser.text = "= "..tostring(num);	
        end)
