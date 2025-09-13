using microsoft.aspnetcore.mvc;
using microsoft.entityframeworkcore;
using dcp_accounts_api.data;
using dcp_accounts_api.models;

namespace dcp_accounts_api.controllers
{
    [route("api/[controller]")]
    [apicontroller]
    public class incomeheadcontroller : controllerbase
    {
        private readonly appdbcontext _context;

        public incomeheadcontroller(appdbcontext context)
        {
            _context = context;
        }

        [httpget]
        public async task<actionresult<ienumerable<incomehead>>> getincomeheads()
        {
            return await _context.incomeheads.tolistasync();
        }

        [httpget("{id}")]
        public async task<actionresult<incomehead>> getincomehead(int id)
        {
            var item = await _context.incomeheads.findasync(id);
            if (item == null) return notfound();
            return item;
        }

        [httppost]
        public async task<actionresult<incomehead>> postincomehead(incomehead item)
        {
            _context.incomeheads.add(item);
            await _context.savechangesasync();
            return createdataction(nameof(getincomehead), new { id = item.incomeheadid }, item);
        }

        [httpput("{id}")]
        public async task<iactionresult> putincomehead(int id, incomehead item)
        {
            if (id != item.incomeheadid) return badrequest();
            _context.entry(item).state = entitystate.modified;
            await _context.savechangesasync();
            return nocontent();
        }

        [httpdelete("{id}")]
        public async task<iactionresult> deleteincomehead(int id)
        {
            var item = await _context.incomeheads.findasync(id);
            if (item == null) return notfound();
            _context.incomeheads.remove(item);
            await _context.savechangesasync();
            return nocontent();
        }
    }
}
